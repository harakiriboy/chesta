import { Route, Link, createBrowserRouter, createRoutesFromElements, Outlet, RouterProvider } from "react-router-dom";
import AnalyticsPage from "./pages/AnalyticsPage";
import AuthorPage from "./pages/AuthorPage";
import CheckoutPage from "./pages/CheckoutPage";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import MembersPage from "./pages/MembersPage";
import PayoutsPage from "./pages/PayoutsPage";
import RegisterPage from "./pages/RegisterPage";
import SearchPage from "./pages/SearchPage";
import SettingsPage from "./pages/SettingsPage";
import "./App.css";
import Navbar from "./layouts/Navbar/Navbar";

function App() {

  const handleLogin = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // Handle the form submission here
  }

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<Root/>}>
        <Route index element={ <HomePage/> } />
        <Route path="/Search" element={ <SearchPage/> } />
        <Route path="/Register" element={ <RegisterPage/> } />
        <Route path="/Login" element={ <LoginPage onSubmit={handleLogin}/> } />
        <Route path="/Settings" element={ <SettingsPage/> } />
        <Route path="/Author" element={ <AuthorPage/> } />
        <Route path="/Members" element={ <MembersPage/> } />
        <Route path="/Payouts" element={ <PayoutsPage/> } />
        <Route path="/Insights" element={ <AnalyticsPage/> } />
        <Route path="/Checkout" element={ <CheckoutPage/> } />
      </Route>
    )
  )
  return (
    <div className="App">
      <RouterProvider router={router}/>
    </div>
  );
}

const Root = () => {
  return (
    <>
    <Navbar/>
    <div><Outlet /></div>
    </>
  );
}

export default App;