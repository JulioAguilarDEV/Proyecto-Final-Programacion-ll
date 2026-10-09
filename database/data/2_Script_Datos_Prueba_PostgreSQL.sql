INSERT INTO public.Sucursal (Nombre, Direccion, Municipio, Departamento, Telefono, HorarioAtencion, Estado) VALUES
    ('Visión Cuilapa', '2a. Calle 3-15 Zona 1', 'Cuilapa', 'Santa Rosa', '78865210', 'Lunes a sábado 8:00 a 18:00', 'Activo'),
    ('Visión Barberena', '4a. Avenida 2-40 Zona 1', 'Barberena', 'Santa Rosa', '78868432', 'Lunes a sábado 8:00 a 17:00', 'Activo'),
    ('Visión Jutiapa', '5a. Calle 6-20 Zona 1', 'Jutiapa', 'Jutiapa', '78441975', 'Lunes a viernes 8:00 a 17:00', 'Activo'),
    ('Visión Escuintla', '7a. Avenida 3-55 Zona 1', 'Escuintla', 'Escuintla', '78883310', 'Lunes a sábado 9:00 a 18:00', 'Activo'),
    ('Visión Zona 1', '6a. Avenida 10-30 Zona 1', 'Guatemala', 'Guatemala', '22305478', 'Lunes a viernes 8:00 a 18:00', 'Inactivo');


INSERT INTO public.Usuario (CodigoSucursal, NombreCompleto, NombreUsuario, Contrasena, Rol, Estado) VALUES
    (1, 'Julio César Aguilar Tije', 'jaguilar', 'Admin123', 'Administrador', 'Activo'),
    (1, 'Diego José Velásquez González', 'dvelasquez', 'Operador1', 'Operador', 'Activo'),
    (2, 'Luis Alfredo Ruano Dealtán', 'lruano', 'Operador2', 'Operador', 'Activo'),
    (3, 'Andrea Sofía Morales Cruz', 'amorales', 'Optica123', 'Optometrista', 'Activo'),
    (4, 'Kevin Estuardo Pérez Lima', 'kperez', 'Optica456', 'Operador', 'Inactivo');


INSERT INTO public.Cliente (Nombres, Apellidos, DPI, FechaNacimiento, Telefono, Correo, Direccion, Estado) VALUES
    ('María Fernanda', 'López Herrera', '2547896320601', '1995-03-12', '50123456', 'maria.lopez@example.com', 'Barrio El Centro, Cuilapa', 'Activo'),
    ('José Miguel', 'Pérez Godoy', '3012458790602', '1988-07-25', '50234567', 'jose.perez@example.com', 'Colonia Los Pinos, Barberena', 'Activo'),
    ('Ana Lucía', 'García Monterroso', '2896541230501', '2001-11-03', '50345678', 'ana.garcia@example.com', 'Zona 3, Jutiapa', 'Activo'),
    ('Carlos Eduardo', 'Méndez Ramírez', '1987456320501', '1975-01-18', '50456789', 'carlos.mendez@example.com', 'Zona 2, Escuintla', 'Activo'),
    ('Rosa Elena', 'Choc Xol', '2210365470101', '1968-09-30', '50567890', NULL, 'Zona 1, Guatemala', 'Activo');


INSERT INTO public.Optometrista (Nombres, Apellidos, NumeroColegiado, Telefono, Correo, Estado) VALUES
    ('Andrea Sofía', 'Morales Cruz', 'OPT-1021', '55123987', 'andrea.morales@visiongt.com', 'Activo'),
    ('Roberto Carlos', 'Juárez Ortiz', 'OPT-1045', '55234876', 'roberto.juarez@visiongt.com', 'Activo'),
    ('Gabriela María', 'Santizo López', 'OPT-1078', '55345765', 'gabriela.santizo@visiongt.com', 'Activo'),
    ('Fernando José', 'Castillo Díaz', 'OPT-1102', '55456654', 'fernando.castillo@visiongt.com', 'Activo'),
    ('Lucía Beatriz', 'Arévalo Pineda', 'OPT-1130', '55567543', 'lucia.arevalo@visiongt.com', 'Inactivo');


INSERT INTO public.Cita (CodigoCliente, CodigoSucursal, CodigoOptometrista, Fecha, Hora, MotivoConsulta, Estado) VALUES
    (1, 1, 1, '2026-09-14', '09:00', 'Visión borrosa de lejos', 'Atendida'),
    (2, 2, 2, '2026-09-15', '10:30', 'Dolor de cabeza al leer', 'Atendida'),
    (3, 3, 3, '2026-09-16', '14:00', 'Revisión anual', 'Atendida'),
    (4, 4, 4, '2026-09-17', '11:00', 'Dificultad para ver de cerca', 'Atendida'),
    (5, 1, 1, '2026-10-05', '15:30', 'Cambio de lentes', 'Programada');


INSERT INTO public.ExamenVisual (CodigoCliente, CodigoOptometrista, CodigoCita, Fecha, Observaciones, ResultadoGeneral, Estado) VALUES
    (1, 1, 1, '2026-09-14', 'Paciente sin antecedentes', 'Miopía leve en ambos ojos', 'Realizado'),
    (2, 2, 2, '2026-09-15', 'Fatiga visual por uso de computadora', 'Astigmatismo leve', 'Realizado'),
    (3, 3, 3, '2026-09-16', 'Revisión de control', 'Visión normal', 'Realizado'),
    (4, 4, 4, '2026-09-17', 'Requiere lentes para lectura', 'Presbicia', 'Realizado'),
    (1, 1, NULL, '2026-09-28', 'Control de adaptación a lentes', 'Miopía estable', 'Realizado');


INSERT INTO public.Receta (CodigoExamen, EsferaOD, CilindroOD, EjeOD, EsferaOI, CilindroOI, EjeOI, Adicion, DistanciaPupilar, FechaEmision, Observaciones, Estado) VALUES
    (1, -1.25, 0.00, 0, -1.00, 0.00, 0, 0.00, 62.0, '2026-09-14', 'Uso permanente', 'Vigente'),
    (2, -0.50, -0.75, 180, -0.25, -1.00, 175, 0.00, 64.0, '2026-09-15', 'Lentes con filtro de luz azul', 'Vigente'),
    (3, 0.00, 0.00, 0, 0.00, 0.00, 0, 0.00, 60.5, '2026-09-16', 'Lentes de descanso opcionales', 'Vigente'),
    (4, 0.50, 0.00, 0, 0.75, 0.00, 0, 2.00, 63.0, '2026-09-17', 'Lentes para lectura', 'Vigente'),
    (5, -1.25, 0.00, 0, -1.00, 0.00, 0, 0.00, 62.0, '2026-09-28', 'Se mantiene la graduación', 'Vigente');


INSERT INTO public.TipoProducto (Nombre, Descripcion, Estado) VALUES
    ('Aros', 'Monturas para lentes oftálmicos', 'Activo'),
    ('Lentes oftálmicos', 'Lentes graduados para corrección visual', 'Activo'),
    ('Lentes de contacto', 'Lentes de contacto blandos y rígidos', 'Activo'),
    ('Lentes de sol', 'Lentes con protección UV', 'Activo'),
    ('Accesorios', 'Estuches, líquidos y paños de limpieza', 'Activo');


INSERT INTO public.ProductoOptico (CodigoTipoProducto, Nombre, Descripcion, Marca, Precio, Estado) VALUES
    (1, 'Aro de metal clásico', 'Aro metálico color plateado', 'Ray-Ban', 650.00, 'Activo'),
    (2, 'Lente monofocal antirreflejo', 'Par de lentes monofocales con antirreflejo', 'Essilor', 450.00, 'Activo'),
    (3, 'Lentes de contacto mensuales', 'Caja de 6 lentes de contacto', 'Acuvue', 275.00, 'Activo'),
    (4, 'Lentes de sol polarizados', 'Lentes polarizados con protección UV400', 'Oakley', 980.00, 'Activo'),
    (5, 'Kit de limpieza', 'Líquido limpiador y paño de microfibra', 'Zeiss', 45.00, 'Activo');


INSERT INTO public.Orden (CodigoCliente, CodigoSucursal, Fecha, Estado) VALUES
    (1, 1, '2026-09-14', 'Entregada'),
    (2, 2, '2026-09-15', 'Entregada'),
    (3, 3, '2026-09-16', 'Entregada'),
    (4, 4, '2026-09-17', 'Lista'),
    (1, 1, '2026-09-28', 'En proceso');


INSERT INTO public.DetalleOrden (CodigoOrden, CodigoProducto, Cantidad, PrecioUnitario, Subtotal) VALUES
    (1, 1, 1, 650.00, 650.00),
    (2, 2, 1, 450.00, 450.00),
    (3, 4, 1, 980.00, 980.00),
    (4, 3, 2, 275.00, 550.00),
    (5, 5, 1, 45.00, 45.00);


INSERT INTO public.Entrega (CodigoOrden, FechaEntrega, NombreRecibe, Observaciones, Estado) VALUES
    (1, '2026-09-18', 'María Fernanda López Herrera', 'Entregado en sucursal', 'Entregada'),
    (2, '2026-09-19', 'José Miguel Pérez Godoy', 'Se ajustó el aro al entregar', 'Entregada'),
    (3, '2026-09-20', 'Ana Lucía García Monterroso', 'Sin observaciones', 'Entregada'),
    (4, '2026-10-03', 'Carlos Eduardo Méndez Ramírez', 'Pendiente de recoger', 'Pendiente'),
    (5, '2026-10-06', 'María Fernanda López Herrera', 'Se notificará por teléfono', 'Pendiente');
