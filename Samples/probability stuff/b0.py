import random
       
def Tx():
     i = 0
     countSakte = 0
     countGabim = 0
     
     while i < 100:
           _inputi = random.randint(0,1000)
           prob = random.randint(0,10)
           if _inputi % 2 == 0 or _inputi % 5 == 0: 
                   if prob <= 7:
                        countGabim += 1
                   elif prob > 7:
                       countSakte += 1
           elif _inputi % 2 != 0 and _inputi % 5 != 0:
                   if prob <= 4:
                       countGabim += 1
                   elif prob > 4:
                       countSakte += 1      
           i += 1

     print(countSakte,"% e ekzekutimeve shfaqen sakte")
     print(countGabim,"% e ekzekutimeve shfaqen gabim")
      
Tx()
input('Shtyp ENTER per ta mbyllur') 
                   
