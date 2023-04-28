// See https://aka.ms/new-console-template for more information
using static Library.Test;

hello("There");

var endpoint = Endpoint.NewInclusive(5);

Console.WriteLine(endpoint.IsExclusive);
Console.WriteLine(endpoint.IsInclusive);

Console.WriteLine(endpoint.ToInt);

Console.WriteLine(endpoint switch
{
  Endpoint.Inclusive e => $"Inclusive {e.Item}",
  Endpoint.Exclusive e => $"Exclusive {e.Item}",
  _ => "Unknown"
});

var interval = new Interval(
  Endpoint.NewInclusive(1),
  Endpoint.NewExclusive(5)
);

Console.WriteLine(interval.ToString());
Console.WriteLine(IntervalToString(interval));

var x = Maybe<string>.NewJust("Hello");
// var x = Maybe<string>.Nothing;

Console.WriteLine(fromMaybe("Nothing", x));

var even = Microsoft.FSharp.Core.FSharpFunc<int, bool>.FromConverter(n => n % 2 == 0);

var y = maybe(false, even, Maybe<int>.NewJust(2));
Console.WriteLine(y);
