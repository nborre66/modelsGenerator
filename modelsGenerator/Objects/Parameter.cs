namespace modelsGenerator.Objects
{
    class Parameter
    {
        private string name;
        private double value;

        public Parameter(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
    }
}

