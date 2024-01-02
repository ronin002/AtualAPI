namespace AtualAPI.Models
{
    public class IFObj
    {
        public string Id { get; set; }
        //public IFExpression Expressao { get; set; }
        public List<ElseIf> ElseIfs { get; set; }
        public bool Entrou { get; set; }
        public int Else { get; set; }
        public int Close { get; set; }
        public int Linha { get; set; }

        public IFObj()
        {
            ElseIfs = new List<ElseIf>();
            Else = 0;
            Entrou = false;
            Close = 0;
        }
        /*
        public Task<int> Execute(int iLinha)
        {
            //https://matheval.org/math-expression-eval-for-c-sharp/
            //string expressao = MDIParentKlango.Instance.Run_CheckVariable(this.Expressao);
            bool result = false;


            if (this.ElseIfs.Count > 0)
            {
                foreach (ElseIf elseif in this.ElseIfs)
                {
                    string vExpressionWithouVars = UtilsExpressions.ReplaceVariables(elseif.Expressao.Expressao());
                    result = UtilsExpressions.CheckExpression(vExpressionWithouVars);
                    if (result)
                    {
                        this.Entrou = true;
                        return Task.FromResult(elseif.iLinha);
                    }
                }
            }
            if (this.Else > 0)
            {
                this.Entrou = true;
                return Task.FromResult(this.Else);
            }

            return Task.FromResult(this.Close);

        }
        */

    }

    public class ElseIfBase
    {
        public string Guid { get; set; }
        public int iLinha { get; set; }
        public string Description { get; set; }
    }
    public class ElseIf : ElseIfBase
    {
        public IFExpression Expressao { get; set; }
        public ElseIf()
        {
            Expressao = new IFExpression();
        }
    }
    public class IFExpression
    {
        public bool Normal { get; set; } = false;
        public string ExpressaoAdvanced { get; set; }
        public string Expressao1 { get; set; }
        public string Compare { get; set; }
        public string Expressao2 { get; set; }

        public string Expressao()
        {
            string sResult = "";

            if (this.Normal)
            {
                sResult = this.Expressao1;
                sResult += this.Compare;
                sResult += this.Expressao2;
            }
            else
            {
                sResult = this.ExpressaoAdvanced;
            }
            return sResult;
        }

    }
}
