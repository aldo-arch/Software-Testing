""" 
######Printimi i rrugeve nga rrenja tek gjethja e pemes
Propozimi i nje strukture "peme" per ushtrimin 1
"""
  
# nyjet e pemes binare permban informacione ,  
# kemi dhe pointer majtas/djathtas (per degezimet) 
class Node: 
    # konstruktori per te krijuar nje nyje 
    def __init__(self, data,tipe,previews): 
        self.data = data 
        self.left = None
        self.right = None
        self.previews = previews
        self.type = tipe   #1 predikat 0 instruksionet
  
# funksioni per te printuar te gjithe rruget
# nga rrenja tek gjethet ne peme binare 
def printPaths(root): 
    # lista per te afishuar rruget
    path = [] 
    printPathsRec(root, path, 0) 
  
# funksion ndihmes per te printuar path-in  
# nga rrenja tek gjethet 
def printPathsRec(root, path, pathLen): 
      
    # kushti baze nese pema binare eshte bosh 
    # return 'empty'
    if root is None: 
        return
  
    # vendos vleren e root-it ne path
     
    if(len(path) > pathLen):
        if(root.previews==0):
            path[pathLen] = root.data+" tipi: %d"%(root.type,)
        else:
                      path[pathLen] = root.data+" tipi: %d"%(root.type,)+" go to: "+root.previews.data
    else:
        if(root.previews==0):
            start = root.data+" tipi: %d"%(root.type,)
        else:
           start = root.data+" tipi: %d"%(root.type,)+" go to: "+root.previews.data
        path.append(start) 
  
    # rrit gjatesine e pathit me 1
    pathLen = pathLen + 1
  
    if root.left is None and root.right is None: 
           
        printArray(path, pathLen) 
    else:  
        printPathsRec(root.left, path, pathLen) 
        printPathsRec(root.right, path, pathLen) 
  
# funksion ndihmes per te pare cfare listohet
def printArray(ints, len): 
    for i in ints[0 : len]:
        print(i," ",end="") 
    print() 
"""

pema e propozuar ne lidhje me u2

                 v[i],t,s=0 
                    /
    .---------->i<v.length
    |          /       \\
    |       /        return S
    |       v[i]>t
    |       /       \\
    |   V[i]%2==0  s=s-V[i]-----------------.
    |        /     \\                       |
    |   s=s+V[i]    s=s-V[i]                |
    |        \\       /                     |
    .------------i++  <---------------------.
     
"""

root = Node("V[i],t,s=0",0,0)
root.left = Node("i < v.length",1,0) 
root.left.right = Node("Return S",0,0)
root.left.left = Node("V[i]>t",1,0)
root.left.left.right = Node ("s=s-V[i]",0,0)
root.left.left.right.right =Node("i++",0,root.left)
root.left.left.left = Node("V[i]%2==0",1,0) 
root.left.left.left.left = Node("s=s+V[i]",0,0)
root.left.left.left.right = Node ("s=s-V[i]",0,0)
root.left.left.left.left.left = Node("i++",0,root.left)
root.left.left.left.right.right = Node ("i++",0,root.left)
printPaths(root)

