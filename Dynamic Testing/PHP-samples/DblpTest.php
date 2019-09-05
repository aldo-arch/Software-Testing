<?php

declare(strict_types=1);

use PHPUnit\Framework\TestCase;


class DblpTest  extends TestCase {

    protected function setUp() : void
    {
        $client = new \Goutte\Client();
        $guzzleClient = new \GuzzleHttp\Client(array( 'curl' => array( CURLOPT_SSL_VERIFYPEER => false, ), )); 
        $client->setClient($guzzleClient);
        
        $this->driver = new \Behat\Mink\Driver\GoutteDriver($client);
        $this->session = new \Behat\Mink\Session($this->driver);

        $this->session->start();
    }

    public function testSearch() : void
    {
        $this->session->visit("http://dblp.uni-trier.de/");
        
        $page = $this->session->getPage();
        
        $page->fillField('q', 'Tirana');
        
        $page->find("css", "#completesearch-form")->submit();
        
        $this->assertTrue($this->session->getPage()->hasContent("2nd International Conference on Recent Trends and Applications in Computer Science and Information Technology"));
    }
    
    public function tearDown() : void
    {
        $this->session->stop();
    }

}