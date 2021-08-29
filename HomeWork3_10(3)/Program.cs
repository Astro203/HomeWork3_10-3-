using System;

namespace HomeWork3_10_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Задание 3. Реализация игры с компьютером
              * 
              * Правила:
              * Загадывается число от 12 до 120, причем случайным образом. Назовем его gameNumber.
              * Игроки по очереди выбирают число от одного до четырех. Пусть это число обозначается как userTry.
              * userTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.
              * Если после хода игрока gameNumber равняется нулю, то походивший игрок объявляется победителем.
              */

            Random rand = new Random(); //добавление генератора случайных чисел

            Console.Write("Пожалуйста, представьтесь: "); string gamer1 = Console.ReadLine(); //ввод своего имени первым игроком
            Console.WriteLine("Ваш соперник персональный компьютер"); string gamer2 = "pc"; //объявление переменной для имени компьютера

            int gameNumber;
            int minNumberMoves;
            int userTry;
            int userTryPC = 3;
            string revansh = "да"; //переменная для возможного реванша
            string winner = ""; //переменная для имени победителя
            while (revansh == "да") //проверка согласия на реванш
            {

                gameNumber = rand.Next(12, 121); //добавление генератора случайных чисел

                for (; ; ) //запуск бесконечного цикла
                {
                    userTry = 0; //перед вводом числа выполнить условие для цикла ниже
                    while (userTry < 1 || userTry > 4) //пока введенное число меньше 1 или болше 4, повторять ввод числа
                    {
                        Console.Write($"{gamer1} введите число от 1 до 4: "); userTry = int.Parse(Console.ReadLine()); //ввод любого целого числа первым игроком 
                    }
                    while (userTry > gameNumber && userTry == 4) //пока введенное число больше оставшегося gameNumber и равно четырем, повторять ввод числа
                    {
                        Console.Write($"{gamer1} введите число от 1 до 3: "); userTry = int.Parse(Console.ReadLine()); //ввод целого числа от 1 до 3 первым игроком 
                    }
                    if (userTry <= gameNumber) //если введенное число меньше или равно оставшегося gameNumber, то выполнить...
                    {
                        gameNumber -= userTry; //вычитание userTry из gameNumber
                        Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося числа
                        if (gameNumber == 0) //если разность равна нулю, то...
                        {
                            Console.WriteLine($"Поздравляем {gamer1} с победой!!!"); //поздравление первого игрока
                            winner = gamer1; //переменная для вывода имени победителя
                            break; //выход из цикла for
                        }
                    }
                    if (userTryPC == 3) userTryPC = 4;
                    else userTryPC = 3;
                    Console.WriteLine($"pc ввел число {userTry}"); //вывод введенного компьютером числа
                    if (gameNumber <= 4) //если оставшийся gameNumber меньше или равен четырем, то выполнить...
                    {
                        userTry = gameNumber; //компьютер вводит число равное gameNumber
                        Console.WriteLine($"pc ввел число {userTry}"); //вывод введенного компьютером числа
                    }
                    if (userTry <= gameNumber) //если введенное число меньше или равно оставшегося gameNumber, то выполнить...
                    {
                        gameNumber -= userTry; //вычитание userTry из gameNumber
                        Console.WriteLine($"Оставшееся число: {gameNumber}"); //вывод оставшегося числа
                        if (gameNumber == 0) //если разность равна нулю, то...
                        {
                            Console.WriteLine($"Поздравляем pc с победой!!!"); //поздравление второго игрока
                            winner = "pc"; //переменная для вывода имени победителя
                            break; //выход из цикла for
                        }
                    }
                }
                //предложение победителю о реванше, если 'да' то продолжить цикл while(revansh), если 'нет' - закончить игру
                Console.Write($"{winner}, Вы согласны на реванш? введите 'да' или 'нет': "); revansh = Console.ReadLine();
            }
        }
    }
}
