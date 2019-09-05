<?php

declare(strict_types=1);

use PHPUnit\Framework\TestCase;


class DblpChromiumTest  extends TestCase {

    protected function setUp() : void
    {
        $this->driver = new \DMore\ChromeDriver\ChromeDriver('http://localhost:9222', null, 'http://www.google.com');
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