<?php

declare(strict_types=1);

use PHPUnit\Framework\TestCase;

final class ArsimiTest extends TestCase
{
    protected $driver;

    protected function setUp() : void
    {
        $client = new \Goutte\Client();
        $guzzleClient = new \GuzzleHttp\Client(array( 'curl' => array( CURLOPT_SSL_VERIFYPEER => false, ), ));
        $client->setClient($guzzleClient);

        $this->driver = new \Behat\Mink\Driver\GoutteDriver($client);
    }


    public function testLajmeShfuqizimi() : void
    {
        $session = new \Behat\Mink\Session($this->driver);
        $session->start();

        $session->visit("http://www.arsimi.gov.al/category/lajme/");
        
        $this->assertTrue($session->getPage()->hasContent("Lajme"));
        
        $session->getPage()->find("css", "#leftContent > div:nth-child(5) > div.descriptionList > h2 > a")->click();
        
        $this->assertTrue($session->getPage()->hasContent("SHFUQIZIMI"));

        $session->stop();
    }

    public function testLajmeHomePage() : void
    {
        $session = new \Behat\Mink\Session($this->driver);
        $session->start();

        $session->visit("http://arsimi.gov.al/");
                
        $session->getPage()->find("css", ".vsrp_div a")->click();
        
        $this->assertTrue($session->getPage()->hasContent("Postuar"));

        $session->stop();
    }

}