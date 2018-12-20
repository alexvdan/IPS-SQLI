import os

licenta_path = 'c:\\Users\\Vdi\\source\\repos\\Licenta\\Licenta\\bin\\Debug\\server\\twisted'
old_path = 'c:\\Python27\\Lib\\site-packages\\twisted'


def main(path):
    # print path
    for ele in os.listdir(os.path.join(licenta_path, path)):
        if os.path.isfile(os.path.join(licenta_path, path, ele)):
            if os.path.isfile(os.path.join(old_path, path, ele)):
                if not os.path.getsize(os.path.join(licenta_path, path, ele)) == os.path.getsize(os.path.join(old_path, path, ele)):
                    print(os.path.join(licenta_path, path, ele))
        elif os.path.isdir(os.path.join(licenta_path, path, ele)):
            main(os.path.join(path, ele))

main('')

