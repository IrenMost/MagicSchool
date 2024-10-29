import './App.css';
import React, { useEffect, useState } from 'react';
import HouseList from './pages/HouseList';
import HouseId from './pages/HouseId';

function App() {
    const [cursorX, setCursorX] = useState(0);
    const [cursorY, setCursorY] = useState(0);

    const isTouchDevice = () => {
        try {
            document.createEvent('TouchEvent');
            return true;
        } catch (e) {
            return false;
        }
    };

    const move = (e) => {
        const touchEvent = e.touches ? e.touches[0] : e;
        const x = !isTouchDevice() ? e.clientX : touchEvent.clientX;
        const y = !isTouchDevice() ? e.clientY : touchEvent.clientY;

        setCursorX(x);
        setCursorY(y);
    };

    useEffect(() => {
        document.addEventListener('mousemove', move);
        document.addEventListener('touchmove', move);

        return () => {
            document.removeEventListener('mousemove', move);
            document.removeEventListener('touchmove', move);
        };
    }, []);

    return (
        <>
            <div className="app-container">
                <p>MAJOOM</p>
                <HouseList />
              

                <style>
                    {`
                    * {
                        margin: 0;
                        cursor: none;
                    }

                    body {
                        background-color: #1a2a3a;
                        height: 100vh;
                        overflow: hidden;
                        display: flex;
                        justify-content: center;
                        align-items: center;
                    }

                    /* Wand handle (rectangle) */
                    #cursor {
                        position: absolute;
                        width: 5px; /* Narrow rectangular handle */
                        height: 40px; /* Lengthen handle */
                        background-color: #a8e6cf;
                        transform: translate(-50%, -50%) rotate(-45deg); /* Rotate to point left */
                        pointer-events: none;
                    }

                    /* Starburst at the top of the wand */
                    #cursor-star {
                        position: absolute;
                        width: 12px;
                        height: 12px;
                        background-color: #a8e6cf;
                        clip-path: polygon(50% 0%, 61% 35%, 98% 35%, 68% 57%, 79% 91%, 50% 70%, 21% 91%, 32% 57%, 2% 35%, 39% 35%);
                        transform: translate(-50%, -50%) rotate(-45deg); /* Rotate to match handle */
                        pointer-events: none;
                    }
                `}
                </style>

                {/* Wand handle */}
                <div
                    id="cursor"
                    style={{ left: `${cursorX}px`, top: `${cursorY}px` }}
                ></div>

                {/* Starburst on top of the wand */}
                <div
                    id="cursor-star"
                    style={{ left: `${cursorX}px`, top: `${cursorY - 20}px` }}
                ></div>
            </div>
        </>
    );
}

export default App;
