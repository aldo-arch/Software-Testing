import time

from selenium import webdriver
from selenium.webdriver.common.keys import Keys

driver = webdriver.Chrome(r"C:\Users\user\PycharmProjects\Autotest\drivers\chromedriver.exe")
driver.get("https://accounts.google.com/signup/v2/webcreateaccount?continue=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dgoogle%26oq%3Dgoogle%26aqs%3Dchrome..69i57j69i65l3.1467j0j1%26sourceid%3Dchrome%26ie%3DUTF-8&hl=sq&flowName=GlifWebSignIn&flowEntry=SignUp")
driver.find_element_by_name("firstName").send_keys('victor')
driver.find_element_by_name("lastName").send_keys('kanievski')
driver.find_element_by_name("Username").send_keys('victor.kanievski77')
driver.find_element_by_name("Passwd").send_keys('victorvicky448484848')
driver.find_element_by_name("ConfirmPasswd").send_keys('victorvicky448484848')
driver.find_element_by_xpath("//*[@id='accountDetailsNext']/content/span").click()
time.sleep(5)
driver.find_element_by_xpath("//*[@id='phoneNumberId']").send_keys('0699363937')
driver.find_element_by_xpath("//*[@id='gradsIdvPhoneNext']/content/span").click()
