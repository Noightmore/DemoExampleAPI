import React from 'react';
import './App.css';
import {Container, Navbar, Nav, NavbarBrand} from "reactstrap";
import Users from './components/Users';

const App: React.FC = () => {
  return (
    <div className="App">
        <Navbar color="dark" light expand="md">
            <NavbarBrand href="/">User loading test app</NavbarBrand>
            <Nav className="mr-auto" navbar>
            </Nav>
        </Navbar>
        <Container>
            <Users/>
        </Container>
    </div>
  );
}


export default App;
