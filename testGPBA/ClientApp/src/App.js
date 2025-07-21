import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import OffersPage from './pages/OffersPage';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/" element={<OffersPage />} />
                    <Route path="/offers" element={<OffersPage />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
