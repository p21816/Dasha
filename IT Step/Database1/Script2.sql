update People
 set PersonalNumber = PersonalNumber + 
 IIF(LEFT('fooo',1) in ('o','a','u','i','e','y'),+20,-10)
