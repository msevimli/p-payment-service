<?php

header('Content-Type: application/json; charset=utf-8');

none("test");
function none($mes)
{
    //echo json_encode(array("mes" => $mes));
?>
{
    "products": [
        {
            "id": 5,
            "categoryId": [
                1,2
            ],
            "productName": "Fanta Orange (0,33 l)",
            "description": "",
            "unitPrice": 25,
            "image": "https://terminal.plife.se/media/TestComp-48/pngegg (20).png"
        },
        {
            "id": 2,
            "categoryId": [
                1,2
            ],
            "productName": "Coca Cola (0,33 l)",
            "description": "",
            "unitPrice": 25,
            "image": "https://terminal.plife.se/media/TestComp-48/pngegg (18).png"
        },
        {
            "id": 26,
            "categoryId": [
                2
            ],
            "productName": "1. Margherita (V)",
            "description": "",
            "unitPrice": 69,
            "image": "https://terminal.plife.se/media/TestComp-48/pngegg (2).png",
            "additional": [
                {
                    "additional_name": "Vælg Ekstra Toppings",
                    "options": [
                        {
                            "option_name": "Chili",
                            "price": 0,
                            "direction": "plus"
                        },
                        {
                            "option_name": "Oregano",
                            "price": 0,
                            "direction": "plus"
                        },
                        {
                            "option_name": "Rosmarin",
                            "price": 0,
                            "direction": "plus"
                        },
                        {
                            "option_name": "Hvidløgsolie",
                            "price": 0,
                            "direction": "plus"
                        }
                    ],
                    "multiple": "true"
                },
                {
                    "additional_name": "Dip Til Skorperne?",
                    "options": [
                        {
                            "option_name": "Dip Aioli",
                            "price": 12,
                            "direction": "plus"
                        },
                        {
                            "option_name": "Dip Devil Sauce",
                            "price": 12,
                            "direction": "plus"
                        },
                        {
                            "option_name": "Dip Remoulade",
                            "price": 12,
                            "direction": "plus"
                        }
                    ],
                    "multiple": "true"
                }
            ]
        }
    ],    
    "categories": [
        {
            "id": 4,
            "name": "Palace Burger",
            "image": "https://terminal.plife.se/media/TestComp-48/pngegg (4).png"
        },
        {
            "id": 2,
            "name": "Pizza",
            "image": "https://terminal.plife.se/media/TestComp-48/pngegg (2).png"
        }
    ],    
    "settings": {
        "lastUpdate": "2023-05-29 00:21:20",
        "storeName": "Burger Palace",
        "storeLogo": "https://terminal.plife.se/media/TestComp-48/59_homescreenlogo_1024x1024 (1).jpeg"
    }
}
<?php
}
