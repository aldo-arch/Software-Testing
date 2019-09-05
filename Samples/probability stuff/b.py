import random

x = int(input("Vendosni nje numer te plote: "))
        
def Tx():
     prob = random.randint(0,10)
     print(prob)

     if x % 2 == 0 or x % 5 == 0:
             print(x, "Perpjesetohet me 2 ose 5")
             if prob <= 7:
                  print("Gabim")
             elif prob > 7:
                  print("Sukses")
     elif x % 2 != 0 and x % 5 != 0:
              print(x, "Nuk perpjesetohet me 2 ose 5")
              if prob <= 4:
                   print("Gabim")
              elif prob > 4:
                   print("Sukses")

Tx()
input('Shtyp ENTER per ta mbyllur') 

                   
