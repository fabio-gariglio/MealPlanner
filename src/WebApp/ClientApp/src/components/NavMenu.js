import React from 'react';
import { Nav, Navbar } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

export function NavMenu() {

  return (
    <Navbar bg="light" expand="lg">
      <NavLink to="/" className="navbar-brand">Meal Planner</NavLink>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="mr-auto">
          <NavLink to="/recipes/creator">Create New</NavLink>
          <NavLink to="/about">About</NavLink>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );

};
