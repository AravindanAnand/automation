using System;
using System.Diagnostics;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;


namespace automation.Repository
{
    public class HomepageOR
    {
        public static By linkMovetoCart=By.Id("shopping_cart_container");

        #region Purchase
        public static string price="";
        public static string name="";
        public static By labelItemPrice=By.XPath("//div[@class='inventory_item_description']//child::div[@class='pricebar']/div[@class='inventory_item_price' and contains(normalize-space(.),'"+price+"')]");
        public static By buttonAddtoCartByPrice=By.XPath("//div[@class='inventory_item_description']//child::div[@class='pricebar']/div[@class='inventory_item_price' and contains(normalize-space(.),'"+price+"')]//following::button[(contains(@id,'add-to-cart'))]");
        public static By labelItemName=By.XPath("//div[@class='inventory_item_description']//child::div[@class='inventory_item_label']//div[contains(normalize-space(.),'"+name+"')]");
        public static By buttonAddtoCartByName=By.XPath("//div[@class='inventory_item_description']//child::div[@class='inventory_item_label']//div[contains(normalize-space(.),'"+name+"')]//following::div[@class='pricebar']/button[(contains(@id,'add-to-cart'))]");
        #endregion

        public static By buttonCheckout=By.Id("checkout");
        public static By txtBoxFirstName=By.Id("first-name");
        public static By txtBoxLastName=By.Id("last-name");
        public static By txtBoxPostalCode=By.Id("postal-code");
        public static By buttonContinue=By.Id("continue");
        public static By buttonFinish=By.Id("finish");
        public static By buttonBackToHome=By.Id("back-to-products");

        
        public static By labelPurchaseSuccessMsg=By.XPath("//h2[@class='complete-header']");


        //Urvann webelements
        public static By txtBoxPincode=By.Id("search1");
        public static By buttonChangePincode=By.XPath("//div[(@class='main-header')]//child::div[@class='table']//child::a[contains(@ng-if,'pincode')]");
        public static string listPincoderesult="//div[@id='automatic']//child::div[contains(@class,'list-group-item')]/div[@class='row']//child::a[@class='searchitem-name']/h4[contains(text(),'#_pincode#')]";

        public static By level1Headers=By.XPath("//div[@id='nav-header']//child::nav[@id='nav-header']//li[contains(@class,'ms-pos-rel')]/a");
        public static string level2Headers="//li[contains(@class,'ms-pos-rel')]//child::a[@title='#_lvl2header#']//following-sibling::ul//a[contains(@class,'font-bold')]";

         public static string level2Item="//li[contains(@class,'ms-pos-rel')]//child::a[@title='#_lvl2header#']//following-sibling::ul//a";
    }
}