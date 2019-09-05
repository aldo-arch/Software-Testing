<?php

class ProductList {
    protected $products;

    function __construct()
    {
        $this->products = [];
    }

    public function add($name, $price)
    {
        $this->products[$name] = $price;
    }

    public function getProductPrice($productName)
    {
        if (array_key_exists($productName, $this->products))
        {
            return $this->products[$productName];
        }
        else
        {
            throw new Exception("This product does not exist");
        }
    }

    public function hasProduct($productName)
    {
        return array_key_exists($productName, $this->products);
    }
}