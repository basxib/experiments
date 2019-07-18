
  var passed = [12, 5, 8, 130, 44].filter( function(element)
  {
      return Check(element).then((res)=> {return res});
  });

   console.log(passed);


  async function Check( element: number) {
    if(element > 10)
      return true;
      else return false;
}