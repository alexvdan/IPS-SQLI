import BaseHTTPServer, SimpleHTTPServer
import ssl
import os


def main():
    httpd = BaseHTTPServer.HTTPServer(('localhost', 8080), SimpleHTTPServer.SimpleHTTPRequestHandler)
    os.chdir('./content')
    # httpd.socket = ssl.wrap_socket(httpd.socket, certfile='../server.pem', server_side=True)
    httpd.serve_forever()

if __name__ == '__main__':
    main()
