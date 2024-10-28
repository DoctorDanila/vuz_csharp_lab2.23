using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vuz_csharp_lab2._23
{
    public struct Time
    {
        private byte _hours;
        private byte _minutes;

        public Time(byte hours, byte minutes)
        {
            if (hours > 23 || minutes > 59)
                throw new ArgumentOutOfRangeException(nameof(hours), nameof(minutes));
            _hours = hours;
            _minutes = minutes;
        }

        public byte Hours => _hours;
        public byte Minutes => _minutes;

        // Метод для вычитания времени
        public static Time operator -(Time t1, Time t2)
        {
            var result = new Time(t1.Hours, t1.Minutes);
            result -= t2;
            return result;
        }

        // Унарное вычитание минуты
        public static Time operator --(Time time)
        {
            time._minutes--;
            if (time._minutes == 0)
            {
                time._hours--;
                time._minutes = 59;
            }
            return time;
        }

        // Операции приведения типа
        public static explicit operator byte(Time time) => time.Hours;

        public static implicit operator bool(Time time) => time != new Time(0, 0);

        // Бинарные операции
        public static Time operator +(Time t1, int minutesToAdd)
        {
            var totalMinutes = t1.Minutes + minutesToAdd;
            var hours = totalMinutes / 60;
            var remainingMinutes = totalMinutes % 60;
            return new Time((byte)(t1.Hours + hours), (byte)remainingMinutes);
        }

        public static Time operator +(int minutesToAdd, Time t)
        {
            return t + minutesToAdd;
        }

        public static Time operator +(Time t1, Time t2)
        {
            return t1 + t2.Minutes;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляров Time
            Time now = new Time(15, 30);
            Time later = new Time(17, 45);

            // Вычитание времени
            Time difference = now - later;
            Console.WriteLine($"Разница: {difference}");

            // Унарное вычитание минуты
            Time minusOneMinute = --now;
            Console.WriteLine($"После вычитания минуты: {minusOneMinute}");

            // Операции приведения типов
            byte hoursAsByte = (byte)now;
            bool isNotNull = now;
            Console.WriteLine($"Часы как byte: {hoursAsByte}");
            Console.WriteLine($"Не нулевое значение: {isNotNull}");

            // Бинарные операции
            Time addedMinutes = now + 30;
            Time sumOfTimes = now + later;
            Console.WriteLine($"Добавление 30 минут: {addedMinutes}");
            Console.WriteLine($"Сумма двух времён: {sumOfTimes}");
        }
    }
}
