import random

print("Shtypni 1 per rastin me te mire")
print("Shtypni 2 per rastin me te keq")
print("Shtypni 3 per random")

_input = int(input(": "))

             
def Tx():
     i = 0
     countSakte = 0
     countGabim = 0
     
     while i < 100:
        if _input == 1:
             nr = 3;
        elif _input == 2:
             nr = 10
        elif _input == 3:
             nr  = random.randint(0,1000)
             
        prob = random.randint(0,10)
        if nr % 2 == 0 or nr % 5 == 0: 
                if prob <= 7:
                    countGabim += 1
                elif prob > 7:
                    countSakte += 1
        elif nr % 2 != 0 and nr % 5 != 0:
                if prob <= 4:
                    countGabim += 1
                elif prob > 4:
                    countSakte += 1      
        i += 1

     print(countSakte,"% e ekzekutimeve shfaqen sakte")
     print(countGabim,"% e ekzekutimeve shfaqen gabim")
      
Tx()
input('Shtyp ENTER per ta mbyllur') 
                   
