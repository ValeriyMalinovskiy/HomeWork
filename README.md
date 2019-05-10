Создайте класс Mammal (млекопитающие). 
Особой чертой млекопитающих является то, что до определенного возраста они вскармливаются молоком матери.
Реализуйте свойство типа int Age. Свойство не должно быть доступно для редактирования.
Реализуйте свойство типа int Weight. Свойство не должно быть доступно для редактирования.
Реализуйте конструктор, который принимает возраст млекопитающего и устанавливает в соответствующее свойство.
Реализуйте метод void Eat(int foodAmount), который принимает параметром количество порций еды и имитирует процесс принятия пищи, а именно выводит на консоль информацию, что кушает млекопитающее в зависимости от возраста. Пусть до 1 года жизни все млекопитающие употребляют молоко, а после - другую еду.
Также предполагается, что после употребления пищи, вес млекопитающего должен увеличиваться на 1 единицу при съеденных 5 порциях еды.

Создайте классы адаптивных типов млекопитающих (наземные, подземные, летающие, водные, древесные): Terrestrial, Subterranean, Arial, Aquatic, Arboreal.

Создайте класс Feeder, который бы позволял кормить млекопитающих.
Реализуйте метод void Feed(Mammal[] mammals).
Реализуйте логику, которая бы позволяла вызывать метод Eat() у каждого экземпляра с разным количеством порций еды и после каждого процесса кормления выводила бы на консоль информацию о том, какой вес млекопитающего после еды.

Создайте по 2 экземпляра из адаптивных типов млекопитающих и поместите их в массив типа Mammal. Причем первый экземпляр должен быть до 1 года возраста, второй - более.
Покормите экземпляры адаптивных типов млекопитающих.

