import { useNavigate } from 'react-router-dom';
import { useContext } from "react";
import { DataContext } from "../../context/DataContext";
import './Logout.css';

const Logout = () => {
    const navigate = useNavigate();
    const { setGlobalData } = useContext(DataContext); 

    const handleLogout = async () => {
        try {
            const response = await fetch('/api/Auth/logout', {
                method: 'POST',
                credentials: 'include',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.ok) {
                alert('Logout successful.');
                setGlobalData(null); // Reset global data to null
                localStorage.removeItem("user"); 
                navigate('/');
            } else {
                const errorText = await response.text();
                console.error(`Error: ${response.status} - ${errorText}`);
                navigate('/');
            }
        } catch (err) {
            console.error(`Fetch error: ${err.message}`);
            navigate('/');
        }
    };

    const handleCancel = () => {
        navigate('/');
    };

    return (
        <div className="logout-container">
            <h1>Are you sure you want to log out?</h1>
            <div className="button-container">
                <button onClick={handleLogout} className="logout-button">Yes</button>
                <button onClick={handleCancel} className="logout-button">No</button>
            </div>
        </div>
    );
};

export default Logout;