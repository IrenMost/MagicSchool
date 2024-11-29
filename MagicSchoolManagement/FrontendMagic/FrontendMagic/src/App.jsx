import './App.css';
import { useRoutes } from "react-router-dom";
import React, { useEffect, useState } from 'react';
import HouseList from './pages/HouseList';
import TeacherList from './pages/TeacherList';
import TeacherUpdater from './pages/updaters/TeacherUpdaterCourse';
import LayoutHome from './components/LayoutHome';
import LayoutTeacher from './components/LayoutTeacher';
import HomePage from "./pages/HomePage";
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
            children: [{ index: true, element: <HouseList /> },
                { path: "HouseList", element: <HouseList /> },
                
            ],
            
        },
        {
            path: "/director",
            element: <LayoutDirector />,
            children: [{ index: true, element: <TeacherList /> },
                { path: "TeacherList", element: <TeacherList /> },
                { path: "TeacherUpdater/:teacherId", element: <TeacherUpdater /> }
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
