public class Kata
{
  public static string IsSortedAndHow(int[] array)
  {
    bool asc = true;
    for(int i=1; i< array.Length ;i++)
    {
      if(array[i] > array[i-1] && asc)
        continue;
       else if(array[i] < array[i-1] && asc && i> 1)
         return "no";
       else if(array[i] < array[i-1])
         asc = false;
    }
    if(asc) return "yes, ascending"; else return "yes, descending";
  }
}