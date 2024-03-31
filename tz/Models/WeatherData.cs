namespace tz
{
    public class WeatherData
    {
        public int Id { get; set; } // Идентификатор записи в базе данных
        public DateTime Date { get; set; } // Дата
        public TimeSpan MoscowTime { get; set; } // Время московское
        public double Temperature { get; set; } // Температура
        public int Humidity { get; set; } // Относительная влажность воздуха
        public double DewPoint { get; set; } // Точка росы
        public int Pressure { get; set; } // Атмосферное давление
        public string WindDirection { get; set; } // Направление ветра
        public int WindSpeed { get; set; } // Скорость ветра
        public int Cloudiness { get; set; } // Облачность
        public int H { get; set; } // H
        public int VV { get; set; } // VV
        public string WeatherPhenomena { get; set; } // Погодные явления
    }

}
