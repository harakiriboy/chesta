import { Route, createBrowserRouter, createRoutesFromElements, Outlet, RouterProvider } from "react-router-dom";
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
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { useAppDispatch } from "./context/configureStore";
import { useEffect } from "react";
import { fetchCurrentUser } from "./features/Account/accountSlice";
import { CssBaseline } from "@mui/material";
import AuthorPublications from "./features/Author/AuthorPublications";
import Membership from "./features/Membership/Membership";
import About from "./features/Author/About";
import CreatePublication from "./features/Publication/CreatePublication";
import EditPublication from "./features/Publication/EditPublication";
import CreateMembership from "./features/Membership/CreateMembership";
import EditMembership from "./features/Membership/EditMembership";
import NoAccess from "./components/NoAccess";


function App() {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchCurrentUser());
  }, [dispatch])

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<Root/>}>
        <Route index element={ <HomePage/> } />
        <Route path="/Search" element={ <SearchPage/> } />
        <Route path="/Register" element={ <RegisterPage/> } />
        <Route path="/Login" element={ <LoginPage /> } />
        <Route path="/Settings" element={ <SettingsPage/> } />
        <Route path=":username" element={ <AuthorPage/> } >
          <Route path="/:username/posts" element={ <AuthorPublications /> } />
          <Route path="/:username/membership" element={ <Membership/> } />
          <Route path="/:username/about" element={ <About/> } />
        </Route>
        <Route path="/Members" element={ <MembersPage/> } />
        <Route path="/Payouts" element={ <PayoutsPage/> } />
        <Route path="/Insights" element={ <AnalyticsPage/> } />
        <Route path="/Checkout" element={ <CheckoutPage/> } />
        <Route path="/Posts/Create" element={ <CreatePublication/> } />
        <Route path="/Posts/Edit" element={ <EditPublication/> } />
        <Route path="/Membership/New" element={ <CreateMembership/> } />
        <Route path="/Membership/Edit" element={ <EditMembership/> } />
        <Route path="/NoAccess" element={ <NoAccess/> } />
      </Route>
    )
  )
  return (
    <div className="App">
      <CssBaseline />
      <ToastContainer position="bottom-right" hideProgressBar theme="colored"/>
      <RouterProvider router={router}/>
    </div>
  );
}

const Root = () => {
  return (
    <>
      <Navbar/>
      <div>
        <Outlet />
      </div>
    </>
  );
}

export default App;