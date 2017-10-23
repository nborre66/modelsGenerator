namespace modelsGenerator.Objects
{
    class Variable
    {
        private string name;
        private double value;

        public Variable(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
