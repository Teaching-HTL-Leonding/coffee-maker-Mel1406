#region var
string product_chosen = "";
decimal money_left = 0m;
decimal price_product = 0m;
decimal change_2 = 0m;
decimal change_1 = 0m;
decimal change_05 = 0m;
decimal one_part = 0m;
int times_hashtag = 0;
const decimal PRICE_CAPPUCCINO = 3.5m;
const decimal PRICE_TEA = 1.5m;
const decimal PRICE_CACAO = 2.5m;
const decimal PARTS = 20m;
const string NO_CREDIT = "Sorry you do not have enough credit left.";
#endregion

Console.OutputEncoding = System.Text.Encoding.Default;
Console.Clear();
do
{
    Console.Write("Please enter how much money you want to insert [valid coins: 0.5, 1, 2💰]: ");
    money_left = decimal.Parse(Console.ReadLine()!);

    if (money_left % 0.5m != 0) { Console.WriteLine("No valid input of coins. Please try again."); }

} while (money_left % 0.5m != 0);

one_part = money_left / PARTS;

while (money_left >= 1.5m && product_chosen != "f")
{
    for (int i = 0; i < Math.Round(money_left / one_part); i++, times_hashtag++)
    {
        Console.Write("#");
    }
    for (int i = 0; i < PARTS - times_hashtag; i++)
    {
        Console.Write(".");
    }
    times_hashtag = 0;
    Console.WriteLine();
    do
    {
        Console.Write("Please enter what products you want to buy [Cappuccino (3.50€)☕ , Tea (1.50€)🍵 , Cacao (2.50€)☕ ] or [f]inish: ");
        product_chosen = Console.ReadLine()!.ToLower();
    } while (product_chosen != "cappuccino" && product_chosen != "tea" && product_chosen != "cacao" && product_chosen != "f");

    switch (product_chosen)
    {
        case "cappuccino": price_product = PRICE_CAPPUCCINO; break;
        case "tea": price_product = PRICE_TEA; break;
        case "cacao": price_product = PRICE_CACAO; break;
        default: price_product = 0m; break;
    }
    if (money_left >= price_product && price_product != 0) { money_left -= price_product; }
    else if (price_product != 0) { Console.WriteLine(NO_CREDIT); }
}

Console.WriteLine($"\nYou get {money_left}€ back");
change_2 = (money_left - money_left % 2m) / 2m;
money_left -= change_2 * 2;
change_1 = (money_left - money_left % 1m) / 1m;
money_left -= change_1 * 1;
change_05 = money_left / 0.5m;

if (change_2 != 0) { Console.WriteLine($"You get {change_2}x2€ pieces"); }
if (change_1 != 0) { Console.WriteLine($"You get {change_1}x1€ pieces"); }
if (change_05 != 0) { Console.WriteLine($"You get {change_05}x0.5€ pieces"); }