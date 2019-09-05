import random

global kodi
global shuma

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
         print (x)
         print(shuma)
         return shuma

     
n = int(input("Numri i iteracioneve: "))
i = 0
while i < n:
    gjenerim()

    i+=1
    
input('Shtyp ENTER per ta mbyllur')  
         
                
    


