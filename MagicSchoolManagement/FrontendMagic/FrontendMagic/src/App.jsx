import './App.css';
import { useRoutes } from "react-router-dom";
import  {  useState } from 'react';
import HouseList from './pages/HouseList';
import TeacherList from './pages/TeacherList';
import AssignAHeadmaster from './pages/AssignAHeadmaster';

import LayoutHome from './components/LayoutHome';
import LayoutTeacher from './components/LayoutTeacher';
import HomePage from "./pages/HomePage";
import TeacherHome from "./pages/TeacherHome";
import LayoutDirector from './components/LayoutDirector';
import Login from "./pages/auth/Login";
import Logout from "./pages/auth/Logout";

import { DataContext } from './context/DataContext';
import Cursor from './components/Cursor';
function App() {
    

    const [globalData, setGlobalData] = useState(null); // userId, userName, password, currentRole*/
  
    const routes = useRoutes([
        {
            path: "/",
            element: <LayoutHome />,
            children: [
                { index: true, element: <HomePage /> },
                { path: "login", element: <Login /> },
                { path: "logout", element: <Logout /> },
                { path: "", element: <HomePage /> },


            ],
        },
        {
            path: "/teacher",
            element: <LayoutTeacher />, 
            children: [{ index: true, element: <TeacherHome /> },
                { path: "HouseList", element: <HouseList /> },
                
            ],
            
        },
        {
            path: "/director",
            element: <LayoutDirector />,
            children: [{ index: true, element: <TeacherList /> },
                { path: "TeacherList", element: <TeacherList /> },
                { path: "AssignAHeadmaster", element: <AssignAHeadmaster />}
               
            ],

        },
    ]);


  

    return (
        <>
            <div className="app-container">
               
                <DataContext.Provider value={{ globalData, setGlobalData }}>
                    {routes}         
                   
                </DataContext.Provider>
               
                <Cursor />
               
            </div>
        </>
    );
}

export default App;
