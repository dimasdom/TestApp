import React from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import Header from './components/Header'
import Login from './components/Login'
import Test from './components/Test'
import Main from './components/Main'
import Result from './components/Result';

function App() {
  const location = useLocation();
  return (
    <div>
      {
        location.pathname.includes("login") ? <></> : <Header />
      }
      <Routes>
        <Route path="/" element={<Main />} />
        <Route path="/login" element={<Login />} />
        <Route path="/test" element={<Test />} />
        <Route path="/result" element={<Result />} />
      </Routes>
    </div>
  );
}

export default App;
