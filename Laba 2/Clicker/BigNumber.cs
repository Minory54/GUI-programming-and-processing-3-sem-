using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    public class BigNumber
    {
        private int[] number = [];
        private const int Base = 3;

        public BigNumber(string number)
        {
            var chunks = Enumerable.Range(0, (number.Length + 2) / 3)
                .Select(i => number.Substring(i * 3, Math.Min(3, number.Length - i * 3)));

            this.number = chunks.Select(int.Parse).ToArray();
        }

        public string GetStringNumber()
        {
            return string.Join("", number);
        }

        public BigNumber GetBigNumber()
        {
            return this;
        }

        public void Add(BigNumber bnum)
        {
            List<int> result = new List<int>();

            int carry = 0; // Перенос
            int maxLength = Math.Max(number.Length, bnum.number.Length);

            // Проходим с конца массивов
            for (int i = 0; i < maxLength; i++)
            {
                int part1 = i < number.Length ? number[number.Length - 1 - i] : 0;
                int part2 = i < bnum.number.Length ? bnum.number[bnum.number.Length - 1 - i] : 0;

                // Складываем соответствующие части и перенос
                int sum = part1 + part2 + carry;

                // Если сумма больше 999, сохраняем перенос
                carry = sum / 1000;
                sum = sum % 1000;

                // Добавляем результат в начало списка
                result.Insert(0, sum);
            }

            // Если остался перенос, добавляем его
            if (carry > 0)
            {
                result.Insert(0, carry);
            }

            // Убираем ведущие нули в результате
            while (result.Count > 1 && result[0] == 0)
            {
                result.RemoveAt(0);
            }

            // Преобразуем список обратно в массив и возвращаем
            number = result.ToArray();
        }

        public void Subtract(BigNumber bnum)
        {
            List<int> result = new List<int>();

            int borrow = 0; // "Занимаем" у старшего разряда
            int maxLength = Math.Max(number.Length, bnum.number.Length);

            // Проходим с конца массивов
            for (int i = 0; i < maxLength; i++)
            {
                int part1 = i < number.Length ? number[number.Length - 1 - i] : 0;
                int part2 = i < bnum.number.Length ? bnum.number[bnum.number.Length - 1 - i] : 0;

                // Вычитаем с учётом "занятия"
                int diff = part1 - part2 - borrow;

                if (diff < 0)
                {
                    // Если результат отрицательный, занимаем у старшего разряда
                    diff += 1000;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                // Добавляем результат в начало списка
                result.Insert(0, diff);
            }

            // Убираем начальные нули
            while (result.Count > 1 && result[0] == 0)
            {
                result.RemoveAt(0);
            }

            // Преобразуем список обратно в массив и возвращаем
            number = result.ToArray();
        }

        public void Multiply(BigNumber bnum)
        {
            // Для хранения результатов умножения
            int[] result = new int[number.Length + bnum.number.Length];

            // Умножаем каждый элемент num1 на каждый элемент num2
            for (int i = number.Length - 1; i >= 0; i--)
            {
                for (int j = bnum.number.Length - 1; j >= 0; j--)
                {
                    // Получаем произведение текущих разрядов
                    int product = number[i] * bnum.number[j];

                    // Находим позицию для добавления в массив результата
                    int posLow = i + j + 1; // Младший разряд
                    int posHigh = i + j;    // Старший разряд (для переноса)

                    // Добавляем произведение к текущему значению на позиции
                    result[posLow] += product;

                    // Обрабатываем перенос, если значение больше 999
                    result[posHigh] += result[posLow] / 1000;
                    result[posLow] %= 1000;
                }
            }

            // Убираем ведущие нули
            List<int> resultList = new List<int>(result);
            while (resultList.Count > 1 && resultList[0] == 0)
            {
                resultList.RemoveAt(0);
            }

            // Преобразуем список обратно в массив и возвращаем
            number = resultList.ToArray();
        }

        public void Divide(BigNumber bnum)
        {
            long divisorValue = ConvertToLong(bnum.number);

            // Проверка на деление на ноль
            if (divisorValue == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            List<int> result = new List<int>();
            long remainder = 0;

            foreach (int part in number)
            {
                // Переносим остаток из предыдущего шага
                remainder = remainder * Base + part;

                // Вычисляем частное для текущей части
                int quotient = (int)(remainder / divisorValue);

                // Вычисляем новый остаток
                remainder = remainder % divisorValue;

                // Добавляем частное в результат
                result.Add(quotient);
            }

            // Убираем начальные нули
            while (result.Count > 1 && result[^1] == 0)
            {
                result.RemoveAt(result.Count - 1);
            }

            // Обратный порядок результата (т.к. мы добавляли с конца)
            result.Reverse();
            number = result.ToArray();
        }

        private static long ConvertToLong(int[] num)
        {
            long result = 0;
            foreach (int part in num)
            {
                result = result * Base + part;

                // Проверка на переполнение
                if (result < 0)
                    throw new OverflowException("Number is too large.");
            }
            return result;
        }

        public override string ToString()
        {
            return string.Join("", number.AsEnumerable().Reverse());
        }
    }
}
