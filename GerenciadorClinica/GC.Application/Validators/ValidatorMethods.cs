namespace GC.Application.Validators
{
    public static class ValidatorMethods
    {
        /// <summary>
        /// Metodo  para validação de CPF
        /// </summary>
        /// <param name="cpf">CPF</param>
        /// <returns><see cref="bool"/></returns>
        public static bool ValidateCPF(string? cpf)
        {
            // Removendo caracteres não numéricos do CPF
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verificando se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificando se todos os dígitos são iguais, o que invalidaria o CPF
            bool digitosIguais = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    digitosIguais = false;
                    break;
                }
            }
            if (digitosIguais)
                return false;

            // Calculando o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * int.Parse(cpf[i].ToString());
            int primeiroDigito = 11 - (sum % 11);
            if (primeiroDigito >= 10)
                primeiroDigito = 0;

            // Verificando se o primeiro dígito verificador é igual ao do CPF
            if (int.Parse(cpf[9].ToString()) != primeiroDigito)
                return false;

            // Calculando o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * int.Parse(cpf[i].ToString());
            int segundoDigito = 11 - (sum % 11);
            if (segundoDigito >= 10)
                segundoDigito = 0;

            // Verificando se o segundo dígito verificador é igual ao do CPF
            if (int.Parse(cpf[10].ToString()) != segundoDigito)
                return false;

            // Se todas as verificações passaram, o CPF é válido
            return true;
        }

        /// <summary>
        /// Método para retorno de mensagem de campo vazio ou nullo.
        /// </summary>
        /// <param name="campo">Um nameof de um campo</param>
        /// <returns><see cref="String"/> Mensagem tratada.</returns>
        public static string MensagemCampoVazioNulo(string campo)
        {
            if (string.IsNullOrEmpty(campo))
                return "Campo vazio!";

            return $"O campo {campo} não pode ser vazio ou nulo.";
        }

        /// <summary>
        /// Método para retorno de mensagem de campo inválido.
        /// </summary>
        /// <param name="campo">Um nameof de um campo</param>
        /// <returns><see cref="String"/> Mensagem tratada.</returns>
        public static string MensagemCampoInvalido(string campo)
        {
            if (string.IsNullOrEmpty(campo))
                return "Campo vazio!";

            return $"Insira um valor válido para o campo {campo}.";
        }

        /// <summary>
        /// Método para retorno de mensagem de range de tamanho.
        /// </summary>
        /// <param name="campo">Um nameof de um campo</param>
        /// <param name="minimo">Valor minimo.</param>
        /// <param name="maximo">Valor maximo</param>
        /// <returns><see cref="String"/> Mensagem tratada.</returns>
        public static string MensagemTamanhoCampo(string campo, int minimo, int maximo)
        {
            if (string.IsNullOrEmpty(campo))
                return "Campo vazio!";

            return $"O {campo} deve conter entre {minimo} à {maximo} caracteres.";
        }

    }
}
