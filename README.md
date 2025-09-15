
<img width="912" height="672" alt="image" src="https://github.com/user-attachments/assets/44dfba43-5a72-4411-af81-8c9c45af399c" />
<img width="857" height="759" alt="image" src="https://github.com/user-attachments/assets/e13e00e4-bd99-406e-9469-26a9ca9acc7e" />





Software Cheesemongers is a company that provides software to support small dairy shops
in Italy that buy and sell different types of cheeses.
The quality of the cheeses often deteriorates as they approach their expiration date. The
company's system is responsible for updating the inventory of the shops.

You recently joined Software Cheesemongers and your first task is to incorporate a new
feature into the system that will enable the shops to sell a new type of cheese. Because of the
high complexity of the current implementation, your task is to improve the quality of existing
code so that future requests for changes will be easier to add.

System overview

1. Each cheese item has two values:

. ValidByDays , which indicates the number of days left before the item expires and
cannot be sold;
Quality , that reflects its overall value.

2. At the end of each day, the application decreases both values by 1 for every cheese item.
3. Once the ValidByDays
times the previous rate.
4. The Quality of an item can never be negative.
5. Parmigiano Regiano is an exception, as it actually increases in Quality
6. The Quality of an item can never exceed 100.
7. Caciocavallo Podolico, which is a renowned cheese, does not need to be sold and does not decrease
class or Items

8. "Tasting with Chef Massimo"is a special event during which the renowned Italian chef teaches
people about cheeses.

This event has a limited duration and, like Parmigiano Regiano, the Quality of the event
increases as its ValidByDays value approaches.
Moreover, the Quality increases faster - by 3 - when a period of 14 days or less
remains, and by 5 when 7 days or less time remains.
. The Quality drops to 0 after the event is over.

Requirements
1. Update the system to support a new type of cheese called "Ricotta".
2. UpdateQuality has to degrade "Ricotta" three times as fast as normal cheeses, because the
freshest "Ricotta" is the most delicious.
3. Refactor the code to improve its quality without changing its original behaviour.
Assumptions

. Make any changes to UpdateQuality
works.
. Do not alter the Item
customers and we promised them it would not be changed.
. UpdateQuality is already covered by unit tests.
· Code quality has to be improved.
Hints

. You can use Console.Write or Console. WriteLine to debug your solution.

Available packages/libraries
. .NET 6.0

and add any new code, ensuring that everything still


using System;
using System.Collections.Generic;


namespace CheeseMongers
{
    public class Program
    {
        private IList<CheeseMongersItem> Items;
        public Program(IList<CheeseMongersItem> items)
        {
            Items = items;
        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Parmigiano Regiano" && Items[i].Name != "Tasting with Chef Massimo")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Caciocavallo Podolico")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 100)
                    {
                        Items[i].Quality = Items[i].Quality + 1;


                        if (Items[i].Name == "Tasting with Chef Massimo")
                        {
                            if (Items[i].ValidByDays < 15)
                            {
                                if (Items[i].Quality < 100)
                                {
                                    if (Items[i].Quality + 2 <= 100 )
                                    {
                                        Items[i].Quality = Items[i].Quality + 2;
                                    }
                                    else
                                    {
                                        Items[i].Quality = 100;
                                    }
                                }
                            }


                            if (Items[i].ValidByDays < 8)
                            {
                                if (Items[i].Quality < 100)
                                {
                                    if (Items[i].Quality + 2 <= 100)
                                    {
                                        Items[i].Quality = Items[i].Quality + 2;
                                    }
                                    else
                                    {
                                        Items[i].Quality = 100;
                                    }
                                }
                            }
                        }
                    }
                }


                if (Items[i].Name != "Caciocavallo Podolico")
                {
                    Items[i].ValidByDays = Items[i].ValidByDays - 1;
                }


                if (Items[i].ValidByDays < 0)
                {
                    if (Items[i].Name != "Parmigiano Regiano")
                    {
                        if (Items[i].Name != "Tasting with Chef Massimo")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Caciocavallo Podolico")
                                {
                                    if (Items[i].Quality - 4 > 0)
                                    {
                                        Items[i].Quality = Items[i].Quality - 4;
                                    } else
                                    {
                                        Items[i].Quality = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                }
            }
        }


    }


    public class CheeseMongersItem
    {
        public string Name { get; set; }


        public int ValidByDays { get; set; }


        public int Quality { get; set; }
    }
}
