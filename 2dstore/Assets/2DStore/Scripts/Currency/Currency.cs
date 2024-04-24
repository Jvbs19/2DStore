public static class Currency
{
    static float m_money = 1000;
    static bool updateUI;

    public static void CalculateMoney(float money)
    {
        m_money += money;
        updateUI = true;
    }
    public static float CheckMoney()
    {
        return m_money;
    }
    public static bool CheckUI()
    {
        return updateUI;
    }
    public static void UiReset()
    {
        updateUI = false;
    }
}
