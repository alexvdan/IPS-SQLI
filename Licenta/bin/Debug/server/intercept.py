import dpkt
import pcap
import os


def main():

    all_if = os.listdir('/sys/class/net/')

    if 'lo' in all_if:
        all_if.remove('lo')

    for i, name in enumerate(all_if):
        print(str(i + 1) + ')' + name)

    print()
    if_nr = 0
    while True:
        try:
            if_nr = int(input('Choose:'))
            if if_nr < 1 or if_nr > len(all_if):
                raise ValueError
            break
        except ValueError:
            print('Invalid input')

    pc = pcap.pcap(all_if[if_nr-1])
    pc.setfilter('tcp')
    for timestamp, packet in pc:
        dpkt.ssl()
        print(dpkt.ethernet.Ethernet(packet))


if __name__ == '__main__':
    main()
