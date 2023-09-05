import React from 'react';
import {Container, Nav, Navbar} from "react-bootstrap";

function Header(props) {
  return (
    <>
      <Navbar collapseOnSelect expand={"lg"} bg={"dark"} variant={'dark'} >
        <Container>
          <Navbar.Brand href={"/"}>Расписание транспорта</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav"/>
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="ms-auto">
              <Nav.Link href={"/routes"}>Маршруты</Nav.Link>
              <Nav.Link href={"/stops"}>Остановки</Nav.Link>

            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  )
    ;
}

export default Header;