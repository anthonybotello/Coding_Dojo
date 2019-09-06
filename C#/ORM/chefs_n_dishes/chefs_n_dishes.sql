.LOCK TABLES `chefs` WRITE;
INSERT INTO `chefs` VALUES (1,"Moose","Phillips","1955-02-17"),(2,"Sally","Stephens","1978-03-11"),(3,"Alfonso","Gutierrez","1990-04-22"),(4,"Terry","McGary","1948-07-02");
UNLOCK TABLES;

.LOCK TABLES `dishes` WRITE;
INSERT INTO `dishes` VALUES (1,"Tastee Burger",670,3,"An okay burger",1),(2,"Banh Mi Taco",250,4,"Some kind of asian taco, I think. How does that even work?",2),(3,"Plain Brown Rice",70,1,"Really, bro? That's the best you could do?",4),(4,"Jerk Chicken Pizza",800,5,"Jerked by a jerk.",3);
UNLOCK TABLES;