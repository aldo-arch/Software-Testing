<?php
class Container {
    
    private $dependencies;
    
    public function __construct()
    {
        $this->dependencies = [];
    }
    
    public function addImpl($interface, $classes)
    {  
        $x=new Implementation();
          $x->interface=$interface;
        for($i=0; $i<Count($classes); $i++)
       { 
        $x->implementations[$i]=$classes[$i];
        }
     $this->dependencies[$interface]=$x;
    }
    
    public function getInstance($class)
    {
        
        $c = new ReflectionClass($class);
        
        $dep = [];
        
        foreach ($c->getConstructor()->getParameters() as $p)
        {
            $interfaceName = $p->getClass()->name;
            
            
            if (!isset($this->dependencies[$interfaceName]))
            {
                throw new Exception("The implementation for interface {$interfaceName} has not been defined.");
            }
            else if (!class_exists($this->dependencies[$interfaceName]->implementations[0]))
            {
                throw new Exception("Class {$this->dependencies[$interfaceName]} does not exist.");
            }
            else 
            {
                $x = Count($this->dependencies[$interfaceName]->implementations)-1;
                $nr=rand(0,$x);
                //gjenerim random
                $dep[$interfaceName] = new $this->dependencies[$interfaceName]->implementations[$nr]();
                var_dump($dep[$interfaceName]);
            }
        }
        
        $instance = $c->newInstanceArgs($dep);
        
        return $instance;
    }
    

        public function getInstanceByCriteria($class,$MethodName)
    {
        
        $c = new ReflectionClass($class);
        
        $dep = [];
        
        foreach ($c->getConstructor()->getParameters() as $p)
        {
            $interfaceName = $p->getClass()->name;
            
            
            if (!isset($this->dependencies[$interfaceName]))
            {
                throw new Exception("The implementation for interface {$interfaceName} has not been defined.");
            }
            else if (!class_exists($this->dependencies[$interfaceName]->implementations[0]))
            {
                throw new Exception("Class {$this->dependencies[$interfaceName]} does not exist.");
            }
            else 
            {
               $implementations= $this->dependencies[$interfaceName]->implementations;
                foreach($implementations as $el)
                {
                    if($el==$MethodName)
                    {   
                         $dep[$interfaceName]=new $el();
                         break;
                    }
                }
              //  $dep[$interfaceName] = new $this->dependencies[$interfaceName]->implementations[0]();
            }
        }
        
        $instance = $c->newInstanceArgs($dep);
        
        return $instance;
    }
}


class Implementation
{
    public $interface;
    public $implementations=[];
}
class OrderProcess{

    private $gw;
    
    public function __construct(GatewayPayment $gw)
    {
        $this->gw = $gw;
    }
    
    public function test()
    {

        $x= $this->gw->process();
        echo "$x";
    }
}




interface GatewayPayment {
    public  function process();
}

class PayCash implements GatewayPayment {
    
    public function process()
    {
      $res='Pagesa u procesua në cash';
      return $res;
    }
}

class PayCreditCard implements GatewayPayment {
    
    public function process()
    {
         $res='Pagesa u procesua nëpërmjet kartës së kreditit';
      return $res;
    }
}

class PayDebit implements GatewayPayment {
    
    public function process()
    {
      $res='Pagesa u procesua nëpërmjet kartës së debitit';
      return $res;
    }
}

class PayCheque implements GatewayPayment {
    
    public function process()
    {
      $res='Pagesa u procesua nëpërmjet çekut';
      return $res;
    }
}
?>