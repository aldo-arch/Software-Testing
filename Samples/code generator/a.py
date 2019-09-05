import random

def gjenerim():
     germat = ["G", "H", "I", "J", "K", "L"]
     a = random.choice(germat)
     b = random.choice(germat)
     
     nr1 = random.randint(2,8)
     nr2 = random.randint(2,8)
     nr3 = random.randint(2,8)
     output = "Kodi gjeneruar eshte {}{}{}{}{}".format(a,b,nr1,nr2,nr3)
     print(output)

     a = germat.index(a)+10
     b = germat.index(b)+10  
     output = "Kodi gjeneruar eshte {} {} {}{}{}".format(a,b,nr1,nr2,nr3)
     print(output)
     shuma = a + b + nr1 + nr2 + nr3
     print("Shuma eshte :",shuma)
     return shuma 
    
def f():
      x = gjenerim() 
      if x % 10 == 0:
           print("Kodi juaj eshte i sakte")     
      elif x % 10 != 0: 
          print("Kodi juaj eshte i gabuar")


f()

input('Shtyp ENTER per ta mbyllur')
