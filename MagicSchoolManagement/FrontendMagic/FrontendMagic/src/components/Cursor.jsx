import React, { useState, useEffect } from 'react';
import './Cursor.css';

const Cursor = () => {
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
            <div
                id="cursor"
                style={{ left: `${cursorX}px`, top: `${cursorY}px` }}
            ></div>
            <div
                id="cursor-star"
                style={{ left: `${cursorX}px`, top: `${cursorY - 20}px` }}
            ></div>
        </>
    );
};

export default Cursor;
