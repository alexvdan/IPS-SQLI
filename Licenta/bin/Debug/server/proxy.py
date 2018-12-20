from twisted.web import proxy, server
from twisted.internet import ssl, reactor, error
from svmutil import *
from twisted.web.resource import Resource
import uri_convertor
import os
import sys
import argparse
import ast
from OpenSSL import crypto

m = None

class BadURL(Resource):
    def render(self, request):
        return ""

class HTTPSReverseProxyResource(proxy.ReverseProxyResource, object):
    def getChild(self, path, request):
        global m

        try:
            features = uri_convertor.uri_to_features(request.uri)
            x0, max_idx = gen_svm_nodearray(features)
            label = libsvm.svm_predict(m, x0)

            if int(label) == 1:
                print('blocked-->sqli:' + request.uri)
                return BadURL()
        except:
            pass
        # print(self.proxyClientFactoryClass.protocol.transport)

        child = super(HTTPSReverseProxyResource, self).getChild(path, request)
        return HTTPSReverseProxyResource(child.host, child.port, child.path,
                                         child.reactor)

def main(args):

    ap = argparse.ArgumentParser()
    ap.add_argument('-c', type=str, default='./server.crt')
    ap.add_argument('-k', type=str, default='./server.key')
    ap.add_argument('-m', type=str, default='./sqli.model')
    ap.add_argument('--server-ip', type=str, default='localhost')
    ap.add_argument('--server-port', type=int, default=8080)
    ap.add_argument('--listen-ip', type=str, default=['192.168.58.1', 'localhost'])
    ap.add_argument('--listen-port', type=int, default=443)
    ns = ap.parse_args(args[1:])

    global m
    m = svm_load_model(ns.m)

    if type(ns.listen_ip) == str:
        ns.listen_ip = ast.literal_eval(ns.listen_ip)
    myProxy = HTTPSReverseProxyResource(ns.server_ip, ns.server_port, '')

    site = server.Site(myProxy)

    if ns.c:
        with open(ns.c, 'rb') as fp:
            ssl_cert = fp.read()
        if ns.k:

            with open(ns.k, 'rb') as fp:
                ssl_key = fp.read()
            certificate = ssl.PrivateCertificate.load(
                    ssl_cert,
                    ssl.KeyPair.load(ssl_key, crypto.FILETYPE_PEM),
                    crypto.FILETYPE_PEM)
        else:
            certificate = ssl.PrivateCertificate.loadPEM(ssl_cert)
        for ele in ns.listen_ip:
            try:
                reactor.listenSSL(ns.listen_port, site, certificate.options(), interface=ele)
            except error.CannotListenError:
                print('Error: ' + ele + ' not a valid interface in this context')
                exit(0)
            except Exception as e:
                print('Error: ' + e.message)
                exit(0)
    else:
        for ele in ns.listen_ip:
            try:
                reactor.listenTCP(ns.listen_port, site, interface=ele)
            except error.CannotListenError:
                print('Error: ' + ele + ' not a valid interface in this context')
                exit(0)
            except Exception as e:
                print('Error: ' + e.message)
                exit(0)
    reactor.run()

if __name__ == '__main__':
    main(sys.argv)