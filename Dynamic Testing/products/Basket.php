<?php

class Basket
{
    protected $productList;
    protected $productsInBasket;

    function __construct($productList)
    {
        $this->productList = $productList;
        $this->productsInBasket = [];
    }

    public function add($name)
    {
         if ($this->productList->hasProduct($name))
         {
             $this->productsInBasket[] = $name;
         }
         else
         {
            throw new Exception("This product does not exist.");
         }
    }

    public function count()
    {
        return count($this->productsInBasket);
    }

    public function getTotalAmount()
    {
        if (count($this->productsInBasket) == 0)
        {
            return 0;
        }
        else
        {
            $total = 0;

            foreach ($this->productsInBasket as $product)
            {
                $total += $this->productList->getProductPrice($product);
            }

            if ($total < 10)
            {
                $shippingCost = 3;
            }
            else
            {
                $shippingCost = 2;
            }

            return 1.2 * $total + $shippingCost;
        }
    }
}