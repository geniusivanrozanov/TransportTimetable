import React, {useState} from 'react';
import {Card, Container} from "react-bootstrap";
import {useParams} from "react-router";
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import RouteCard from "../components/RouteCard";

const Stop = () => {
  const {id} = useParams()
  const {data: stop} = useFetch(baseUrl + "/api/stops/" + id)

  return (
    <>
      <Container className={"d-flex justify-content-center align-items-center"}>
        {
          stop &&
          <Card>
            <Card.Header>{stop.name}</Card.Header>
            <Card.Body>{stop.routes.map(route => <RouteCard route={route} stop={stop}></RouteCard>)}</Card.Body>
          </Card>
        }
      </Container>
    </>
  );
};

export default Stop;