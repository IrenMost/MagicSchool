import { Outlet } from "react-router-dom";
import { DataContext } from '../context/DataContext'
import { useContext } from "react";

const LayoutTeacher = () => {
    const globalData = useContext(DataContext)
    console.log(globalData)

    //const firstName = globalData?.globalData?.firstName;

    return (
        <div className="container">
           
           <main className="main">
            {/* Display a default message if firstName is not available */}
            <p style={{ color: '#a8e6cf' }}>
                    Welcome {/*firstName ? firstName : 'Guest'*/} {globalData.globalData.firstName }
            </p>
            <Outlet />
        </main>

        </div>
    ) ;
};

export default LayoutTeacher;