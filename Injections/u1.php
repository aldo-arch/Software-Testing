<?php
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

//REFERENCA : klesti/sample-dependency-container
//            Injektimi i varësive 
//URL : https://github.com/klesti/sample-dependency-container
//      https://docs.google.com/a/fshnstudent.info/viewer?a=v&pid=sites&srcid=ZnNobi5lZHUuYWx8Y291cnNlLTM5fGd4OjZlNmY3NTU0ZmQ1MTEzZmM

class Container {
    
    private $dependencies;
    
    public function __construct()
    {
        $this->dependencies = [];
    }
    
    public function addImpl($interface, $class)
    {
        $this->dependencies[$interface] = $class;
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
            else if (!class_exists($this->dependencies[$interfaceName]))
            {
                throw new Exception("Class {$this->dependencies[$interfaceName]} does not exist.");
            }
            else 
            {
                $dep[$interfaceName] = new $this->dependencies[$interfaceName]();
            }
        }
        
        $instance = $c->newInstanceArgs($dep);
        
        return $instance;
    }   
}
?>