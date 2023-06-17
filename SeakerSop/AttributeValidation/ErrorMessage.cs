namespace SeakerSop.AttributeValidation
{
    public static class ErrorMessage
    {
        public const string PasswordCompareError = "Пароли не совпадают";
        public const string NameLengthError = "Имя должно быть длинной от 3 до 12 символов";
        public const string LastNameLengthError = "Фамилия должна быть длинной от 5 до 15 символов";
        public const string AgeError = "Возраст должен быть в области от 14 до 80 лет";
        public const string NameRequired = "Вы не ввели Имя";
        public const string LastNameRequired = "Вы не ввели Фамилию";
        public const string AgeRequired = "Вы не ввели Возраст";
        public const string AdressRequired = "Вы не ввели Адрес";
        public const string GmailRequired = "Вы не ввели Gmail";
        public const string PasswordRequired = "Вы не ввели Пароль";
        public const string AdressLengthError = "Длинна адреса должна быть от 8 до 20 символов";
        public const string PasswordDBError = "Данный пароль уже занят пожалуйста введите другой";
        public const string GmailLoginError = "Не верно введена почта";
        public const string PasswordlLoginError = "Неверно введен пароль";
        public const string SurNameRequired = "Вы не ввели отчество";
        public const string SurNameLengthError = "Отчество должно быть в диапазоне от 5 до 14 символов";
        public const string CardNumberRequired = "Вы не ввели номер карты";
        public const string CVCCodeRequired = "Вы не ввели CVC код";
        public const string DateRequired = "Вы не ввели дату";
    }
}
