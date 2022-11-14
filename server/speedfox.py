import os
import time
while (1 == 1):
    
    os.system("pkill speedfoxserver")

    time.sleep(5)

    os.system("curl http://8.219.147.117:5844/api/server/mail.php?mail=2272990582@qq.com")
    os.system("curl http://8.219.147.117:5844/api/server/mail.php?mail=1154699966@qq.com")

    time.sleep(5)

    os.system("./speedfoxserver -C c.yml")