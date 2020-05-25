# LaCashKassenbuch
Die [LaCash Kassensoftware](https://www.lacash.de) ist ein komplettes Kassensystem. Kassenbücher zur Abrechnung können dort ebenfalls erstellt werden.
Die Erstellung von klassischen Kassenbüchern im zweispaltigen Layout (z. B. zur Weiterverwendung durch den den Steuerberater) kann mit dieser Software nachgerüstet werden.

# Anwendung
- Das Kassenbuch wird innerhalb von LaCash unter dem Namen "Kassenbuchexport.mdb" exportiert.
- LaCashKassenbuch wird aufgerufen und erzeugt ein Kassenbuch zur Weiterverarbeitung in einer Textverarbeitung


# Beispielausgabe
````
ZEIT   BON-NR  TEXT                                     EINNAHME       AUSGABE                        KASSENBEST.  
—————————————————————————————————————————————————————————————————————————————————————————————————————————————————
01.03.2017     ANFANGSBESTAND                                                                         3138,80 EUR
                                                                                                     ————————————
09:22    1410  BARVERKAUF                             155,00 EUR                                      3293,80 EUR  
10:58    1411  BARVERKAUF                              19,00 EUR                                      3312,80 EUR  
11:51    1412  BARVERKAUF                              30,00 EUR                                      3342,80 EUR  
12:17    1413  KARTENZAHLUNG / GIRO                                                                                
14:07    1414  BARVERKAUF                             280,00 EUR                                      3622,80 EUR  
14:33    1415  KARTENZAHLUNG / GIRO                                                                                
14:34  100015  PORTO                                                  2,60 EUR                        3620,20 EUR  
14:56  100016  PORTO                                                  6,90 EUR                        3613,30 EUR  
16:37    1416  KARTENZAHLUNG / GIRO                                                                                
16:53    1417  BARVERKAUF                             290,00 EUR                                      3903,30 EUR  
17:13    1418  KARTENZAHLUNG / GIRO                                                                                
18:07    1419  BARVERKAUF                              10,00 EUR                                      3913,30 EUR  
18:46  100017  Kassendifferenz                                     3913,30 EUR                           0,00 EUR  
                                                                                                     ————————————
               ENDBESTAND                             784,00 EUR   3922,80 EUR                           0,00 EUR
               SALDO                                                                                 -3138,80 EUR
````

