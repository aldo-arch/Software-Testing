import random
import time

sakte = 0
gabim = 0
def gjenerim():
     germat = ["G", "H", "I", "J", "K", "L"]
     a = random.choice(germat)
     b = random.choice(germat)
     
     nr1 = random.randint(2,8)
     nr2 = random.randint(2,8)
     nr3 = random.randint(2,8)
     kodi = a, b, nr1, nr2, nr3
     x=''
     x=x.join(str(i) for i in kodi)
     
     a = germat.index(a)+10
     b = germat.index(b)+10    

     shuma = a + b + nr1 + nr2 + nr3
     
     if shuma % 10 == 0:
         print("Kodi i  sakte eshte: ", x)
         return True
     elif shuma % 10 != 0:
         print("Kodi i gabuar eshte: ", x)
         return False
     gabim+=1



timeout = time.time() + 10    
while True:
    rez = gjenerim()
    if rez:
        sakte+=1
    elif not rez:
        gabim +=1
    if time.time() > timeout:
        break     

shuma=sakte + gabim
print("Shuma eshte: ", shuma)
print("Nr i kodeve sakte: ", sakte)
print("Nr i kodeve gabim: ", gabim)
print("Besueshmeria: ", round(((shuma-gabim)/shuma) * 100,2), "%")
     
input('Shtyp ENTER per ta mbyllur')

