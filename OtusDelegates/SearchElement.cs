namespace OtusDelegates
{
    //1.Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
    //Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
    //public static T GetMax(this IEnumerable e, Func<T, float> getParameter) where T : class;

    public static class SearchElement
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> getParameter) where T : class
        {
            T retVal = null;

            float max = float.MinValue;

            foreach (T item in collection)
            {
                float f = getParameter(item);

                if (f > max)
                {
                    retVal = item;
                    max = f;
                }
            }

            return retVal;
        }

        private static float GetParameter<T>(T param) where T : class => param switch
        {
            IFloatNum iFloatNum => iFloatNum.Value,
            float f => f,
            _ => throw new ArgumentException("Невозможно преобразовать тип")
        };

        public static void Start()
        {
            List<IFloatNum> list = new() { new FloatNum(1f), new FloatNum(4.55f), new FloatNum(-1f) };
            float retVal = list.GetMax<IFloatNum>(GetParameter).Value;
            Console.WriteLine(retVal);
        }
    }
}
