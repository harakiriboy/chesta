import { useEffect, useState } from "react";

function App() {
  const [products, setProducts] = useState([
    {date: 'prod1', summary: "sum1"},
    {date: 'prod2', summary: "sum2"},
    {date: 'prod3', summary: "sum3"},
  ]);

  useEffect(() => {
    fetch('https://localhost:7014/WeatherForecast')
      .then(response => response.json())
      .then(data => setProducts(data))
  }, [])

  function addProduct() {
    setProducts(prevState => [...prevState, 
      { date: 'prod' + (prevState.length + 1), summary: '' + ((prevState.length*100) + 100) }])
  }

  return (
    <div>
      <h1>Re-store</h1>
      <ul>
        {products.map((item, index) => (
          <li key={index}>{item.date} - {item.summary}</li>
        ))}
      </ul>
      <button onClick={addProduct}>Add new product</button>
    </div>
  );
}

export default App;
